            Application application = new Application {Visible = true};
            string styleName1 = "Heading 1";
            object styleNameObject1 = styleName1;
            string styleName2 = "Heading 2";
            object styleNameObject2 = styleName2;
            var document = application.Documents.Add();
            document.Select();
            application.Selection.set_Style(ref styleNameObject2);
            Style style = (Style)application.Selection.get_Style();
            Style baseStyle = style.get_BaseStyle();
            style.set_BaseStyle(ref styleNameObject1);
            application.Selection.Range.Text = "This is the title";
            application.Quit(false);
