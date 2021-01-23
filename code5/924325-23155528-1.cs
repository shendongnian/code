    foreach (var drawable in drawables) {
        DrawableObject target;
        drawable.TryGetTarget(out target);
        if(target == null || target.IsDead) {
            drawables.Remove(drawable);
        }
        else {
            spriteBatch.Draw(target.Texture, target.Position, target.Rectangle, target.Colour);
        }
    }
