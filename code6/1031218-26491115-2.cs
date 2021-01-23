    StreamWriter writer;
    if(permLine_ == ""){return;}
    foreach (Control C in this.Controls)
    {
        if (C.GetType() == typeof(System.Windows.Forms.CheckBox))
        {
            if (!permLine_.Contains(C.Name))
            {
                C.Visible = false;
            }
        }
    }
    using (writer = new StreamWriter("...."))
    {
        writer.Write(permLine_);
    }
