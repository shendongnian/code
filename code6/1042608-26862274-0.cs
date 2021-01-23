     return
          new SelectList(
              Enum.GetValues(typeof (TEnum))
                  .Select(e => new SelectListItem
                  {
                     Text = Enum.GetName(typeof (TEnum), e),
                     Value = e.ToString()
                  })
                  .ToList(),
              "Value",
              "Text");
