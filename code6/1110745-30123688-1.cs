    String iCall = CreateICal();
                System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType("text/calendar");
                ct.Parameters.Add("charset", @"utf-8");
                ct.Parameters.Add("method", "REQUEST");
                AlternateView avCal = AlternateView.CreateAlternateViewFromString(iCall, ct);
                System.Net.Mime.ContentType cthtml = new System.Net.Mime.ContentType("text/html");
                cthtml.Parameters.Add("charset", @"utf-8");
                AlternateView avHtml = AlternateView.CreateAlternateViewFromString(this.mHTML, cthtml);
                mail.AlternateViews.Add(avHtml);
                mail.AlternateViews.Add(avCal);
                foreach (LinkedResource resource in arrattach)
                {
                    avHtml.LinkedResources.Add(resource);
                }
                client.Send(mail);
