    var request = new ChangeResourceRecordSetsRequest
    {
        HostedZoneId = hostedZoneId,
        ChangeBatch = new ChangeBatch
        {
            Changes = new List<Change>
            {
                new Change
                {
                    Action = ChangeAction.CREATE,
                    ResourceRecordSet = new ResourceRecordSet
                    {
                        Name = GetQualifiedName(domainName),
                        Type = RRType.A,
                        AliasTarget = new AliasTarget
                        {
                            HostedZoneId = "Z2F56UZL2M1ACD",
                            DNSName = "s3-website-us-west-1.amazonaws.com.",
                            EvaluateTargetHealth = false,
                        },
                    },
                },
            }
        }
    };
