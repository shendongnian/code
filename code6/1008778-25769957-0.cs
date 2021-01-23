        private void textBox1_Leave(object sender, EventArgs e)
        {
            //I have left textbox1, get my text
            var s = textBox1.Text;
            //db update
            var ctx = new mydbEntities();
            ctx.configTable.Where(x => x.id == 1).Single().Value = s;
            // commit changes to db
            ctx.SaveChanges();
        }
