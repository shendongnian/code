    if (Model.Model2 == null
      || Model.Model2.Model3 == null
      || Model.Model2.Model3.Model4 == null
      || Model.Model2.Model3.Model4.Name == null)
    {
      mapped.Name = "N/A"
    }
    else
    {
      mapped.Name = Model.Model2.Model3.Model4.Name;
    }
