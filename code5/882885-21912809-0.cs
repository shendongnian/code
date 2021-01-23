    for (int i = 0; i < Model.Questions.Count(); i++)
    {
       @Html.DropDownListFor(m => 
           m.Questions[i].Id,
           new SelectList(
               m.Questions[i].Options, 
               "Text",
               "Value",
               m.Questions[i].Options.SingleOrDefault(x = > x.IsChecked).Value))
    }
