    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    using System.Data.OleDb;
    using System.Windows.Forms;
    namespace pomp_benzin
    {
        class class_print
        {
            public void print_to_html_file(string str_sql,int count_field,string[] headers)
            {
                //خط زير تنها كانكشن استرينگ را ميخواند كه ميتوان ان را نيز به صورت دستي نوشت
                OleDbConnection con=new OleDbConnection(vars.con_str);
                OleDbCommand cmd=new OleDbCommand(str_sql,con);
                con.Open();
                OleDbDataReader rd=cmd.ExecuteReader();
                TextWriter tw = new StreamWriter(Application.StartupPath + "\\a.html", false, Encoding.UTF8);
                tw.WriteLine("<table dir='rtl' border='1' style='width:100%;border-style:solid'>");
                //ساخت هدر هر ستون در جدول با توجه به هدر هاي ارسال شده از طرثق آرايه
                tw.WriteLine("<tr>");
                for (int i = 0; i < headers.Length; i++)
                {
                    tw.WriteLine("<td style='background-color: #CCCCCC;border-style:solid'>");
                    tw.WriteLine(headers[i]);
                    tw.WriteLine("</td>");
                }
                while(rd.Read())
                {
                    tw.WriteLine("<tr>");
                    for (int cel = 0; cel < count_field; cel++)
                    {
                        tw.WriteLine("<td style='border-style:solid'>");
                        //محتويات يك فيلد از جدول مربوطه
                        tw.WriteLine(rd.GetValue(cel).ToString());
                        //محتويات يك فيلد از جدول مربوطه
                        tw.WriteLine("</td>");
                    }
                    tw.WriteLine("</tr>");
                }
                tw.WriteLine(" </table>");
                con.Close();
                tw.Close();
                System.Diagnostics.Process.Start(Application.StartupPath + "\\a.html");
            }
        }
    }
