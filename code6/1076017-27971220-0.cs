    .Columns(columns =>
          {
              columns.Bound(e => e.ConcatName).EditorTemplateName("NameLookupConcatenated"); //changed name here
              columns.Bound(e => e.Phone);
              columns.Bound(e => e.Email);
              columns.Command(command => { command.Edit(); command.Destroy(); });
          })
