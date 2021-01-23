    private Customer customer = new Customer();
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
               customer.Name = "test";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Console.WriteLine(customer);   //Why is this null ?
    }
}
