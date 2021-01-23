    public static List<dynamic>   Test() {
    
                List<CompressedLogResponse> list = new List<CompressedLogResponse>();
    
                var result = list.Select(x => new
                { 
                    x.LoggerAnnounceTime,
                    x.LoggerType,
                    x.NewLogId,
                    x.NumberOfRegisters
                });
    
                return result.ToList<dynamic>();
            }
