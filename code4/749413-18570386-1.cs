    private void btnExport_Click(object sender, EventArgs e)
    {
        (...)
            //Form1 obj = new Form1();
            Form1 obj = pointerToForm1;
            foreach (Row r in tblProxiesLive.Rows)
            {
                obj.loadsecondtable(r.Cells[1].Text);
                sw.Write(r.Cells[1].Text + "\r\n");
            }
        (...)
    }
