    item.Channels.Select((c, i) => new { Channel = c, Index = i })
                 .Where(x => !x.Channel.IsSkipped)
                 .ForEach(x =>
                 /* x.Channel is your item, x.Index is its original Index */
                 );
                 
