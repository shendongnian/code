    public static string GetUsername(this Uri uri)
            {
                if (uri == null || string.IsNullOrWhiteSpace(uri.UserInfo))
                    return string.Empty;
                var items = uri.UserInfo.Split(new[] { ':' });
                //Replace precent encoding in the username.
                var result = Uri.UnescapeDataString(items[0]);
                return result.Length > 0 ? result : string.Empty;
            }
