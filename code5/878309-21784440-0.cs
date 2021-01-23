     this.myComboBox.DisplayMember = "Value";
     this.myComboBox.ValueMember = "Key";
     this.myComboBox.DataSource = Enum.GetValues(typeof(EduTypePublicEnum))
                                      .Cast<EduTypePublicEnum>()
                                      .ToDictionary(e => e.ToString());
