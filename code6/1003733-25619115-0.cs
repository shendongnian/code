    private void sumNumbers()
      {
          float.TryParse(txtGTC.Text, out n1);
          float.TryParse(txtPF.Text, out n2);
          float.TryParse(txtbasicsalery.Text, out n3);
          float.TryParse(txthoserent.Text, out n4);
          float.TryParse(txtlicrent.Text, out n5);
          float.TryParse(txtDA.Text, out n6);
          float.TryParse(txtCCA.Text, out n7);
          grossalery = n1 + n2 + n3 + n4 + n5 + n6 + n7;
          txtgrosssalery.Text = Convert.ToString(grossalery);
      }
