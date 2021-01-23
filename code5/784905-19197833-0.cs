     using (var db = new Database1Entities())
     {
     Student s = new Student();
     s.Name = StudentName.Text;              
     s.Address = Address.Text;
 
     try 
     {
         db.Students.Add(s);
         int numOfUpdate = db.SaveChanges();
         MessageBox.Show("Addition Successfull:" + numOfUpdate.ToString() + "updates");
     }
     catch(Execption ex)
     {
         MessageBox.Show("Addition Failed:" + ex.Message);
     }
     }
