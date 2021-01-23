           public static string DisplayText(string str , int charallowed){
                if(str.Length > charallowed)
                       return str.Substring(0,charallowed) + " ...." ;
                return str;
            }
            @Html.DisplayFor(modelItem => DisplayText(item.Text,20)); 
