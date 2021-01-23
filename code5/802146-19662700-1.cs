    public void BindData(object tel){
       if(txtTelName.DataBindings["Text"] != null) 
          txtTelName.DataBindings.Remove(txtTelName.DataBindings["Text"]);
       txtTelName.Add("Text", tel, "T_Name", false, DataSourceUpdateMode.OnPropertyChanged);
       if(chkActive.DataBindings["Checked"] != null)
          chkActive.DataBindings.Remove(chkActive.DataBindings["Checked"]);       
       chkActive.DataBindings.Add("Checked", tel, "T_Active", true, DataSourceUpdateMode.OnPropertyChanged);       
       if(txtNotes.DataBindings["Text"] != null)
         txtNotes.DataBindings.Remove(txtNotes.DataBindings["Text"]);       
       txtNotes.DataBindings.Add("Text", tel, "T_Notes", true, DataSourceUpdateMode.OnPropertyChanged);
    }
    //then use it like this:
    tel = new Model.DatabaseModels.Tel();
    tel.T_Active = BusinessLogic.Enums.StatusCodes.Active;
    BindData(tel);
