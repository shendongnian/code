            ServicePoint srvrPoint = ServicePointManager.FindServicePoint(serverUri);
            MethodInfo ReleaseConns = srvrPoint.GetType().GetMethod
                    ("ReleaseAllConnectionGroups",
                    BindingFlags.Instance | BindingFlags.NonPublic);
            ReleaseConns.Invoke(srvrPoint, null);
