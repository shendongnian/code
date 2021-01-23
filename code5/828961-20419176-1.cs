            //StringBuilder sb = new StringBuilder();
            HtmlGenericControl myDiv = new HtmlGenericControl("div");
            myDiv.InnerText = "I want to change this text";
            //Make sure asp.net does not add any prefix to your Id "example"
            myDiv.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            myDiv.ID = "example";
            //Examples using a literal, placeholder or a lable:
            litExample.Text = RenderControl(myDiv);
            phExample.Text = RenderControl(myDiv);
            lblExample.Text = RenderControl(myDiv);
            //Do Stuff with myDiv as typical control
