    private void btnValidate_Click(object sender, EventArgs e)
    {
         string text = btnDrank4.Text;
         switch(text)
         {
               case "Drank1":
                  btnDrank1.Text = txtNaam.Text + "\n" + txtInhoud.Text + "cl";
                  drank[0].Naam = txtNaam.Text;
                  drank[0].Inhoud = txtInhoud.Text;
                  drank[0].Prijs = Convert.ToDouble(txtPrijs.Text);
               break;
               case "Drank2":
               // your code here
               break;
               // here the other cases
               default ""
               // here everything is not the previous values
               // I suppose these lines
               MessageBox.Show("6 dranken is genoeg!", "My Application",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
               break;
         }
    }
