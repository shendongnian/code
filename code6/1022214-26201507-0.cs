    var data = channels.Select(c => new {c.Number,
                                         c.HighestCoChannelSignal,
                                         c.HighestOverlappingSignal,
                                         NetsCoChannelCount = c.NetsCoChannel.Count,
                                         NetsOverlappingCount = c.NetsOverlapping.Count})
                       .ToArray();
