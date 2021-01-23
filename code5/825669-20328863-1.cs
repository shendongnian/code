    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
        namespace Test
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    DataSet dataSet1 = new DataSet("dataSet");
                    DataTable dataTable1 = dataSet1.Tables.Add("Table");
                    DataColumn dataColumn1 = dataTable1.Columns.Add("Valor", typeof(decimal));
                    dataTable1.PrimaryKey = new DataColumn[] { dataColumn1 };
                    DataRow dRow = dataSet1.Tables["Table"].NewRow();
                    dRow["Valor"] = Convert.ToDecimal("1985,56");
                    dataSet1.Tables["Table"].Rows.Add(dRow);
                    dRow = dataSet1.Tables["Table"].NewRow();
                    dRow["Valor"] = Convert.ToDecimal("85,756");
                    dataSet1.Tables["Table"].Rows.Add(dRow);
                    dRow = dataSet1.Tables["Table"].NewRow();
                    dRow["Valor"] = Convert.ToDecimal("145,6");
                    dataSet1.Tables["Table"].Rows.Add(dRow);
                    InitializeComponent();
                    if (dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0] != null && dataSet1.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dataRowTemp in dataSet1.Tables[0].Rows)
                        {
                            Debug.Print(dataRowTemp["Valor"].ToString());
                        }
                        dataGridView1.DataSource = dataTable1;
                    }
                    //var provider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    var provider = new System.Globalization.CultureInfo("pt-BR");
                    //var provider = new System.Globalization.CultureInfo("en");
                    dataGridView1.Columns["Valor"].DefaultCellStyle.FormatProvider = provider;
                    dataGridView1.Columns["Valor"].DefaultCellStyle.Format = "C2";
                    dataGridView1.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }
