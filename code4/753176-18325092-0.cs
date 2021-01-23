    foreach (var mesh in Model.Meshes)
    {
       foreach (BasicEffect effect in mesh.Effects)
       {
           effect.EnableDefaultLighting();
           effect.TextureEnabled = true;
           effect.Texture = modelTexture;
           effect.Projection = Camera.Projection;
           effect.View = Camera.View;
           effect.World = AbsoluteBoneTransforms[mesh.ParentBone.Index] * FinalWorldTransforms;
        }
        mesh.Draw();
    }
