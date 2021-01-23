    public class HowToUseAsserts
    {
        int expectedSdvCount = 0;
        int expectedSdVirtualId = 0;
        string expectedSdvEntityType = "";
        EntityModelMultiIndexEntities context;
        public HowToUseAsserts()
        {
            context = new EntityModelMultiIndexEntities();
        }
    
        [Fact]
        public void Search_display_view_count_should_be_the_same_as_expected()
        {
            context.SearchDisplayViews.Should().HaveCount(expectedSdvCount);
        }
        [Fact]
        public void Search_display_view_virtual_id_should_be_the_same_as_expected()
        {
            context.VirtualID.Should().Be(expectedSdVirtualId);
        }
        [Fact]
        public void Search_display_view_entity_type_should_be_the_same_as_expected()
        {
            context.EntityType.Should().Be(expectedSdvEntityType);
        }
    }
