    private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
    {
      string value = comboBox1.Text;   //car brand
      Type type = Type.GetType("YOUR_NAMESPACE." + value);
      var brand_models = Enum.GetNames(type);
      foreach (string enumValue in brand_models)
      {
        string brand_model = enumValue;
        MessageBox.Show(brand_model);
      }
    }
