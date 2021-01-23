    private GridViewInfo GetViewInfo(GridView view)
        {
            FieldInfo fi;
            fi = typeof(GridView).GetField("fViewInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            GridViewInfo griInfo = fi.GetValue(view) as GridViewInfo;
            if (griInfo != null)
             {
              // check if scrollbar
              if (griInfo.VScrollBarPresence == ScrollBarPresence.Visible)
              {
                  Console.WriteLine("Scrollbar visible");
              }
              else
              {
                  Console.WriteLine("Scrollbar not visible");
              }
            }
            return griInfo;
        }
