    public class PersonInfo
    {
         public string Name;
         public string Id;
         public string phoneNumber;
    }
    List<PersonInfo> persons = new List<PersonInfo>();
    // after reading values
    persons.Add(new PersonInfo(txtName.Text, txtId.Text, txtPhoneNumber.Text));
    // if you don't have a constructor like that defined;
    personse.Add(new PersonsInfo {
                        Name = txtName.Text;
                        Id = txtId.Text;
                        PhoneNumber = txtPhoneNumber.Text;
                 });
