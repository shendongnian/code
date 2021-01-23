    public struct ProfileData {
        public readonly ExpressionBuildingEventArgs Info;
        public readonly TimeSpan Elapsed;
        public ProfileData(ExpressionBuildingEventArgs info, TimeSpan elapsed) {
            this.Info = info;
            this.Elapsed = elapsed;
        }
    }
    static void EnableProfiling(Container container, List<ProfileData> profileLog) {
        container.ExpressionBuilding += (s, e) => {
            Func<Func<object>, object> profilingWrapper = creator => {
                var watch = Stopwatch.StartNew();
                var instance = creator.Invoke();
                profileLog.Add(new ProfileData(e, watch.Elapsed));
                return instance;
            };
            Func<object> instanceCreator = 
                Expression.Lambda<Func<object>>(e.Expression).Compile();
            e.Expression = Expression.Convert(
                Expression.Invoke(
                    Expression.Constant(profilingWrapper),
                    Expression.Constant(instanceCreator)),
                e.KnownImplementationType);
        };
    }
