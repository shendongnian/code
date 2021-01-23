    var participantID = String.Join(", ",
                                    xdoc.Root.Elements("Participant")
                                             .Select(e => e.Attribute("ParticipantID"))
                                             .Where(a => a != null)
                                             .Select(a => a.Value)
                                             .Distinct());
