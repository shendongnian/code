          EntityFramework_mvcEntities db = new EntityFramework_mvcEntities();
          
            int i =Convert.ToInt32( txtsrch.Text);
            Employee p = db.Employees.Find(i);
            
            TextBox1.Text = p.Name;
             TextBox2.Text = p.Email;
            TextBox4.Text = p.Mobile;
            db.SaveChanges();
        }
