        protected void Button_Click(object sender, EventArgs e)
        {
            string s = "Some text.\r\nSecond line.";
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=testfile.txt");
            Response.AddHeader("content-type", "text/plain");
            using (StreamWriter writer = new StreamWriter(Response.OutputStream))
            {
                writer.WriteLine(s);
            }
            Response.End();
        }
    }
