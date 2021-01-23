    if(!string.IsNullOrEmpty(this.txtenter.Text) && 
           !(txtenter.Text.Replace(',' ,'').Any(x => char.IsLetter(x)))
    {
         string[] temp = txtenter.Text.Split(',');
         ...
    }
     
