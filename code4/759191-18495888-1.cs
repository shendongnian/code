private void btn_click(object sender, EventArgs e)
{
  PCPrint.PrintDocument(txtName.Text); // If static
  
  PCPrint printer = new PCPrint();
  printer.PrintDocument(txtName.Text); // If not static
  PCPrint.GetInstance().PrintDocument(txtName.Text); // If singleton
}
