    this.Paragraphs[1].Range.InsertParagraphBefore();
    this.Paragraphs[1].Range.Select();
    Microsoft.Office.Tools.Word.ContentControl checkBoxControl1 = 
         this.Controls.AddContentControl("checkBoxControl1", Word.WdContentControlType.wdContentControlCheckBox);
    checkBoxControl1.Checked = true;
