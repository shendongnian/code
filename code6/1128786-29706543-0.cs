    ShimInputRepository
                .AllInstances
                .UpdateEngagementStringNullableOfInt64NullableOfInt32String = (xInst, xEngId, xTrimUri, xTargetVers, xComments) =>
                    {
                        if (xEngId != initializer.SeededEngagementsWithoutEmp[3].EngagementId)
                        {
                            return ShimsContext.ExecuteWithoutShims(() => xInst.UpdateEngagement(xEngId, xTrimUri, xTargetVers, xComments));
                        }
                        else
                        {
                            throw new Exception
                                    (
                                        "An error occurred while executing the command definition. See the inner exception for details.",
                                        new Exception
                                        (
                                            "A transport-level error has occurred when receiving results from the server. (provider: Session Provider, error: 19 - Physical connection is not usable)"
                                        )
                                    );
                        }
                    };
