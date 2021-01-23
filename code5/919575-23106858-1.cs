            protected void Page_Load(object sender, EventArgs e)
            {
             try
             {
              if (!IsPostBack)
               {
                       ddl_UOM_SelectedIndexChanged(sender, e );
               }
          
             }
           catch (Exception)
           {
            throw;
           }
         }
