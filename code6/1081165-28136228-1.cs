           public static string DisplayText(this string str , int charallowed){
                if(str.Length > charallowed)
                       return str.Substring(0,charallowed) + " ...." ;
                return str;
            }
            @Html.DisplayFor(modelItem => item.TextDisplayText(20)); 
