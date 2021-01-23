    var milestones = LoadMilestones(session).Select(
                    m => {
                        var id = GetSafeValue(m.Attribute("id").Value);
                        object answer; // the type should be whatever you are expecting.
                        ans.TryGetValue(id, out answer);
                        return new
                        {
                            milestoneid = id,
                            duedate = GetSafeValue(m.XPathValue("duedate")),
                            answer = answer
                        };
                    }).ToArray()
