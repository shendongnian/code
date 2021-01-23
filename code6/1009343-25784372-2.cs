    To receive authorization, the client sends the userid and password,
    separated by a single colon (":") character, within a base64 [7]
    encoded string in the credentials.
      basic-credentials = base64-user-pass
      base64-user-pass  = <base64 [4] encoding of user-pass,
                       except not limited to 76 char/line>
      user-pass   = userid ":" password
      userid      = *<TEXT excluding ":">
      password    = *TEXT
