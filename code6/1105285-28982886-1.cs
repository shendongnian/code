    <ModelVisual3D x:Name="Models">
        <ModelVisual3D.Transform>
            <Transform3DGroup>
                <RotateTransform3D>
                    <RotateTransform3D.Rotation>
                         <AxisAngleRotation3D Axis="1,0,0" Angle="{Binding varX}"/>
                    </RotateTransform3D.Rotation>
                </RotateTransform3D>
                <RotateTransform3D>
                    <RotateTransform3D.Rotation>
                        <AxisAngleRotation3D Axis="0,1,0" Angle="{Binding varY}"/>
                    </RotateTransform3D.Rotation>
                </RotateTransform3D>
                <RotateTransform3D>
                    <RotateTransform3D.Rotation>
                         <AxisAngleRotation3D Axis="0,0,1" Angle="{Binding varZ}"/>
                    </RotateTransform3D.Rotation>
                </RotateTransform3D>
            </Transform3DGroup>
        </ModelVisual3D.Transform>
    </ModelVisual3D>
