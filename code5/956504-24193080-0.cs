    public bool DeleteScenario(string featureName, string scenarioName)
        {
            var collection = GetCollection<Feature>();
            var query = Query.EQ("FeatureName", featureName);
            var resultingFeature = collection.Find(query).SetLimit(1).FirstOrDefault();
            if (resultingFeature == null)
            {
                return false;
            }
            // we have found our feature and it exists.
            foreach (var scenario in resultingFeature.Scenarios)
            {
                if (scenario.ScenarioName == scenarioName)
                {
                    resultingFeature.Scenarios.Remove(scenario);
                    collection.Save(resultingFeature);
                    return true;
                }
            }
            return true;
        }
