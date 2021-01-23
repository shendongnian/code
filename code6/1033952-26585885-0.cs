    using System.Threading;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public class GPS
            {
                public String ObjName;
                private Int32 Loc;
                private DateTime date;
    
                public void setLoc(Int32 Location)
                {
                    Loc=Loc+Location;
                }
    
                public Int32 getLoc()
                {
                    return Loc;
                }
    
                public void setDate(DateTime s)
                {
                    date = s;
                }
    
                public DateTime getDate()
                {
                    return date;
                }
    
                public GPS(String n)
                {
                    ObjName =String.Copy(n);
                    Random rnd1 = new Random();
                    Loc = rnd1.Next(50);
                }
            }
    
            SqlConnection cs = new SqlConnection("Data Source=RAMAPRIYASR17A6;Initial Catalog=ex_1; Integrated Security=TRUE");
            System.Data.SqlClient.SqlCommand cmd=new System.Data.SqlClient.SqlCommand();
            private Thread myThread;
    
            public Form1()
            {
                InitializeComponent();
                myThread = new Thread(trackGPS);
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                cs.Open();
                SqlCommand SelectCommand = new SqlCommand("select TIME from m where NAME=@name and LOCATION=@location",cs);
                SelectCommand.Parameters.Add("@name", tb2.Text);
                SelectCommand.Parameters.Add("@location", tb3.Text);
                SelectCommand.ExecuteNonQuery();
    
                SqlDataReader reader = SelectCommand.ExecuteReader();
                if (reader.Read())
                {
                    answerlabel.Text = reader.GetString(0);
                }
    
                cs.Close();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                cs.Open();
                SqlCommand SelectCommand = new SqlCommand("select LOCATION from m where NAME=@name and TIME=@time", cs);
                SelectCommand.Parameters.Add("@name", tb2.Text);
                SelectCommand.Parameters.Add("@time", tb1.Text);
                SelectCommand.ExecuteNonQuery();
    
                SqlDataReader reader = SelectCommand.ExecuteReader();
    
                if (reader.Read())
                {
                    answerlabel.Text = reader.GetString(0);
                }
    
                cs.Close();
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                myThread.Start();
            }
    
            private void button4_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    
            private void trackGPS() 
            {
                GPS a = new GPS("A"); 
    
                Random rnd = new Random();
                Random time_skip = new Random();
    
                while(true)
                {  
                    Int32 skip_or_not = time_skip.Next(-61, 600);//if <0 then GPS off
    
                    //We check if skip_or_not < 0
    
                    if(skip_or_not<0)//GPS off or off radar
                    {
                        Int32 tChangePos = rnd.Next(-50, 50);
                        a.setLoc(tChangePos);
    
                        DateTime w = DateTime.Now;
                        TimeSpan timew = new TimeSpan(0, 0, 20, 0,0);//20 mins off radar
                        DateTime combined = w.Add(timew);
                        a.setDate(combined);
                    }
                    else
                    {
                        Int32 ChangePos = rnd.Next(-6, 6);
                        a.setLoc(ChangePos);
    
                        a.setDate(DateTime.Now);
                    }
    
                    string stmt = "INSERT INTO m(TIME,LOCATION,NAME) VALUES(@time, @location,@name)";
    
                    SqlCommand cmd = new SqlCommand(stmt, cs);
                    cmd.Parameters.Add("@time", SqlDbType.VarChar, 100);
                    cmd.Parameters.Add("@location", SqlDbType.VarChar, 100);
                    cmd.Parameters.Add("@name", SqlDbType.VarChar, 100);
    
                    cmd.Parameters["@time"].Value = a.getDate().ToString("t");
                    cmd.Parameters["@location"].Value = a.getLoc().ToString();
                    cmd.Parameters["@name"].Value = a.ObjName.ToString();
    
                    cs.Open();
                    cmd.ExecuteNonQuery();
                    cs.Close();
                }
            }
        }
    }
