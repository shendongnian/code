    @helper Accordion(string text, System.Web.Mvc.HtmlHelper<dynamic> html)
    {
       <div class="accordion">
           <div><h4>Das ist der Header</h4></div>
           <div>
               <p>Das ist der Content</p>
               <p>@text</p>
               @using(html.RoleContainer())
               {
                   for(int i = 0; i < 4; i++){
                       <li>
                           @i: Test
                       </li>   
                   }
               }
           
           </div>
       </div>
    }
