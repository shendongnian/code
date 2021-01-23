    For this you have to use Ajax call. 
    
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
        <script type="text/javascript">
            $(function () {
                $('#Button1').click(getListofStudents);
            });
    
            function getListofStudents() {
                $.ajax({
                    type: "Post",
                    url: "Default.aspx/getListofStudents",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var  ListofStudents= response.d;
                        alert(ListofStudents.length);
                    },
    
                    failure: function (msg) {
                        $('#lblerror').text(msg);
                    }
                });
            }
    
        </script>
    
    
    And then on .cs file 
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Services;
    using System.Collections;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
    
       [WebMethod]
       public static Array getListofStudents()
       {
          ArrayList  ListofStudents= new ArrayList();
          ListofStudents.Add("jhon");
          ListofStudents.Add("Shon");
          ListofStudents.Add("Mohan");
          return ListofStudents.ToArray();
       }
    
    }
    This is one of the best example of getting work from .cs file using Json Service.
 
