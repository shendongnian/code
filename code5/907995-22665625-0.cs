        Private Function ToEpoch(value As Date) As Double
            Dim span As TimeSpan = (value.ToUniversalTime -
                                        New System.DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
            Return span.TotalMilliseconds
        End Function
