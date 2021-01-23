    Here is best solution for this issue:
    
    In View add all the ID(Keys). 
    Consider having multiple tables named(First,Second and Third)
    
    @Html.HiddenFor(model=>model.FirstID)
    @Html.HiddenFor(model=>model.SecondID)
    @Html.HiddenFor(model=>model.Second.SecondID)
    @Html.HiddenFor(model=>model.Second.ThirdID)
    @Html.HiddenFor(model=>model.Second.Third.ThirdID)
    
    [HttpPost]
    Public ActionResult Edit(First first){
       if(ModelState.Isvalid){
 
         If(First.FirstID>0){
            datacontext.Entry(first).State=EntityState.Modified;
            datacontext.Entry(first.Second).State=EntityState.Modified;
            datacontext.Entry(first.Second.Third).State=EntityState.Modified;
        }
        else
        {
            datacontext.First.Add(first);
        }
       datacontext.SaveChanges()
       Return RedirectToAction("Index");
      }
     
    Return View(first);
    }
