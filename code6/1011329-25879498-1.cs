    protected override void OnRenderFrame( FrameEventArgs e ) {
        base.OnRenderFrame( e );
        GL.MatrixMode( MatrixMode.Modelview );
        GL.Clear( ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit );
        GL.EnableClientState( ArrayCap.VertexArray );
        GL.EnableClientState( ArrayCap.TextureCoordArray );
        GL.DisableClientState( ArrayCap.ColorArray );
        /**
         * Pass 1
         * Normal Rendering && Occlusion Test
         */
        GameCamera.LookThrough( this , _mousePosition , e );
        if(NeedsOcclusionPass) {
            foreach(Voxel voxel in World.VisibleVoxels) {
                if(GameCamera.Frustum.SphereInFrustum(voxel.Location.X, voxel.Location.Y, voxel.Location.Z, 2.0f)) {
                    GL.BeginQuery(QueryTarget.SamplesPassed, voxel.OcclusionID);
                    voxel.Render(GameCamera);
                    GL.EndQuery(QueryTarget.SamplesPassed);
                }
            }
            NeedsOcclusionPass = false;
        } else {
            foreach( Voxel voxel in World.VisibleVoxels ) {
                if( GameCamera.Frustum.SphereInFrustum( voxel.Location.X , voxel.Location.Y , voxel.Location.Z , 2.0f ) ) {
                    GL.NV.BeginConditionalRender( voxel.OcclusionID , NvConditionalRender.QueryNoWaitNv );
                    voxel.Render( GameCamera );
                    GL.NV.EndConditionalRender();
                }
            }
            NeedsOcclusionPass = true;
        }
        
        GL.DisableClientState( ArrayCap.VertexArray );
        GL.DisableClientState( ArrayCap.TextureCoordArray );
        GL.DisableClientState( ArrayCap.ColorArray );
        //RenderDeveloperHud();
        SwapBuffers();
        this.Title = GAME_NAME + " FPS: " + ( int )this.RenderFrequency;
    }
