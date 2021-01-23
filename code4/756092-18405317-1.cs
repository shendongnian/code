    static void Main(string[] args)
    {
        var contacts = new List<Contact>();
        contacts.Add(new Contact { Firstname = "name 1", Lastname = "lastname 1", Email = "email 1", PhoneNumber = "phone 1" });
        contacts.Add(new Contact { Firstname = "name 2", Lastname = "lastname 2", Email = "email 2", PhoneNumber = "phone 2" });
        Excel.Application app = new Excel.Application();
        app.Visible = true;
        var workbook = app.Workbooks.Add();
        _Worksheet worksheet = workbook.Sheets["Sheet1"];
        Range xlRange = worksheet.UsedRange;
        worksheet = (_Worksheet)workbook.ActiveSheet;
        worksheet.Cells[1, 1] = "First Name";
        worksheet.Cells[1, 2] = "Last Name";
        worksheet.Cells[1, 3] = "Email";
        int row = 4;
        foreach (var contact in contacts)
        {
            row++;
            worksheet.Cells[row, 1] = contact.Firstname;
            worksheet.Cells[row, 2] = contact.Lastname;
            worksheet.Cells[row, 3] = contact.Email;
            worksheet.Cells[row, 4] = contact.PhoneNumber;
        }
        app.UserControl = true;
    }
    public class Contact
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
