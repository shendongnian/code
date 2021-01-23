    try
                            {
                                if (GeekFunction(
                                    handleBoneIndices.AddrOfPinnedObject(),
                                    handleVertexRemap.AddrOfPinnedObject(),
                                    Convert.ToUInt32(boneindices.data.Length),
                                    Convert.ToUInt32(sizeof(VertexData.Index4)), null) != 0)
                                    StatusOutput.FatalError("GeekFunctionFailed: boneIndices");
                            }
                            finally
                            {
                                handleBoneIndices.Free();
                                handleVertexRemap.Free();
                            }
    
    **handleVertexRemap = GCHandle.Alloc(vertexRemap, GCHandleType.Pinned);**
    
    try
                            {
                                if (scePsp2VertexCacheApplyVertexRemapping(
                                    handleBoneIndices.AddrOfPinnedObject(),
                                    handleVertexRemap.AddrOfPinnedObject(),
                                    Convert.ToUInt32(boneindices.data.Length),
                                    Convert.ToUInt32(sizeof(VertexData.Index4)), null) != 0)
                                    StatusOutput.FatalError("scePsp2VertexCacheApplyVertexRemapping Failed: boneIndices");
                            }
                            finally
                            {
                                handleBoneIndices.Free();
                                handleVertexRemap.Free();
                            }
