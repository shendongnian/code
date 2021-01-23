    protected void Page_Load(object sender, EventArgs e)
            {
                //the ugly way, fastest that answers your question
                TheUglyWay();            
            }
    
    
    
            
    
            private void TheUglyWay()
            {
                StringBuilder innerHtml = new StringBuilder();
                for(var i = 0; i < 3; i++){
                    string li = @"
        <li class=""liSubSpecialty active"" data-trait-id=""9"">
            <a href=""test.htm"" class=""premote trait-link large btn"" data-trait-id=""9"">
                <span class=""check""><i class=""icon icon-ok""></i></span>
                <span class=""name"">Cardiology</span>
                <span class=""count"">6</span>
            </a>
        </li>";
                    innerHtml.AppendLine(li);
                }
    
                ulSpecialty_selector.InnerHtml = innerHtml.ToString();
            }
