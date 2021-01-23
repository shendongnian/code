    private static void GetSubtest(List<Subtest> subtestList) {
            foreach (var subtest in subtestList) {
                if (subtest.Subtests != null) {
                    GetSubtest(subtest.Subtests);
                }
                else {
                    // add data to Vertica cluster
                }
            }
        }
