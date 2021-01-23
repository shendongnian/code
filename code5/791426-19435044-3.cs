    foreach (var item in value)
    {
      if (!item.Descendants<PIC.Picture>().Any())
      {
        p.Append(item.CloneNode(true));
      }
      else
      {
        p.Append(CreateImageRun(source, item, target, f));
      }
    }
