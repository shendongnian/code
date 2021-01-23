     //it shows the number of line that inserted 
                private int _inserteditemCount;
                //its number of items in each column
                private int _itemsCount;
                //liign height use for determine paragraph line height
                private const string Lineheight = "30px";
        
                protected void Page_Load(object sender, EventArgs e)
                {
                    _inserteditemCount = 0;
                    var alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                    var listCountcount = new Thingsclass().GetThings().Count;
                    //Count of rows on dictionary + number of leters
                    _itemsCount = (listCountcount + alpha.Count()) / 2;
                    var leftdiv = new HtmlGenericControl("div");
                    var rightdiv = new HtmlGenericControl("div");
                    //you can change this styles 
                    leftdiv.Style.Add("display", "inline-block");
                    leftdiv.Style.Add("width", "50%");
                    leftdiv.Style.Add("float", "Left");
                    rightdiv.Style.Add("display", "inline-block");
                    rightdiv.Style.Add("float", "right");
                    rightdiv.Style.Add("width", "50%");
                    foreach (var c in alpha)
                    {
                        var lblAlphaCharacter = new Label();
                        lblAlphaCharacter.Font.Size = 24;
                        lblAlphaCharacter.Font.Bold = true;
                        lblAlphaCharacter.Text = c.ToString(CultureInfo.InvariantCulture);
                        var control = _inserteditemCount <= _itemsCount ? leftdiv : rightdiv;
                        var paragraph = new HtmlGenericControl("p");
                        paragraph.Style.Add("line-height", Lineheight);
                        paragraph.Controls.Add(lblAlphaCharacter);
                        control.Controls.Add(paragraph);
                        FilterOnAlphaCharacter(leftdiv, rightdiv, c.ToString());
                        _inserteditemCount++;
                    }
                    Panel1.Controls.Add(leftdiv);
                    Panel1.Controls.Add(rightdiv);
                }
        
                private void FilterOnAlphaCharacter(Control leftctr, Control rightctr, string character)
                {
                    var items = new Thingsclass().GetThings().Where(c => c.chara.ToLower().Equals(character.ToLower()));
        
                    foreach (var item in items)
                    {
                        var paragraph = new HtmlGenericControl("p");
                        paragraph.Style.Add("line-height", Lineheight);
                        var control = _inserteditemCount <= _itemsCount ? leftctr : rightctr;
        
                        var title = item.Title;
                        var description = item.Description;
                        var link = new HyperLink { Text = title };
                        paragraph.Controls.Add(link);
        
                        var lblDescription = new Label { Text = string.Format(" - {0}", description) };
                        paragraph.Controls.Add(lblDescription);
                        _inserteditemCount++;
                        control.Controls.Add(paragraph);
                    }
                }
