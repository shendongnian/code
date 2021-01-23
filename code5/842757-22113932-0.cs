                FX db1 = new FX();
            LibraryManagementSystemEntities db2 = new LibraryManagementSystemEntities();
           
            Thread thread1 = new Thread(delegate()
            {
                db1.insert2(TextBox1.Text,TextBox2.Text);
                db2.insert1(TextBox1.Text,TextBox2.Text);
                //tbl_RegistrationDetail DATA = new tbl_RegistrationDetail();
                //DATA.FirstName = TextBox1.Text;
                //DATA.MiddleName = TextBox2.Text;
                //Student_Registration data = new Student_Registration();
                //data.firstname = TextBox1.Text;
                //data.middlename = TextBox2.Text;
                //db1.AddTotbl_RegistrationDetail(DATA);
                //db2.AddToStudent_Registration(data);
                //db1.SaveChanges();
                //db2.SaveChanges();
            });
           thread1.Start(); 
        }
