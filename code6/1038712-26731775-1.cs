    public class AddedContacts
    {
        public readonly List<CreateContact> Contact = new List<CreateContact>();
    }
    private void button4_Click(object sender, EventArgs e)
    {
        CreateContact p = new CreateContact(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
        AddedContacts ac= new AddedContacts();
        ac.Contact.Add(p);
    }
