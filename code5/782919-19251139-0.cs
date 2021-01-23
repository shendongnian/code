    public SelectList GetMyDDLData(int? selectedValue){
        var data = fooRepository.GetAll().Select(x => new { Value = x.Id, Text = x.Name });
        return new SelectList(data, "Id","Name", selectedValue);
    }
  
