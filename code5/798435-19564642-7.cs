    System.Drawing.Font fnt = new System.Drawing.Font(
      rtf_Renamed.SelectionFont.FontFamily, 
      rtf_Renamed.SelectionFont.Size,
      (System.Drawing.FontStyle)(rtf.SelectionFont.Style
        ^ rtf_Renamed.SelectionFont.Underline 
        ? System.Drawing.FontStyle.Strikeout
        : System.Drawing.FontStyle.Underline
      )
    );
