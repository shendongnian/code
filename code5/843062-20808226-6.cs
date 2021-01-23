            var message = new StringBuilder(500);
            foreach (var request in requests) {
              if (!string.IsNullOrEmpty(request.Result)) {
                if (message.Length == 0) {
                    message.Append("Sorry, the following website(s) failed: ");
                } else {
                    message.Append(", ");
                }
                message.Append(request.Url);
              }
            }
