     for (int i = 0; i < myGroupList.Items.Count; i++)
        {
            if (element.Children[i].InnerText == "abc_group")
            {
                element.SetAttribute("selected", "selected");
                break;
            }
        }
