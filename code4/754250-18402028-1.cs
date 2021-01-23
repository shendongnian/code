    this.ResponseFilters.Add((req, res, dto) =>
    {
      if (!(dto is IHaveLinks))
        return;
      var links = (dto as IHaveLinks).Links
      if(links == null || !links.Any())
        return;
      var linksText = links
        .Select(x => string.Format("<{0}>; rel={1}"), x.Request.ToUrl(x.Method), x.Name));
      var linkHeader = string.Join(", ", linksText);
      res.AddHeader("Link", linkHeader);
    });
