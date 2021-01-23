    private static IEnumerable<BodyPartBasic> GetBasicBodyParts(this BodyPart part)
    {
        var multipart = part as BodyPartMultipart;
        var basic = part as BodyPartBasic;
        if (multipart != null)
        {
            foreach (var subPart in multipart.BodyParts)
            {
                if (subPart is BodyPartBasic)
                {
                    yield return subPart as BodyPartBasic;
                }
                else
                {
                    foreach (var subSubPart in subPart.GetBasicBodyParts())
                    {
                        yield return subSubPart;
                    }
                }
            }
        } else if (basic != null)
        {
            yield return basic;
        }
        else
        {
            yield break;
        }
    }
